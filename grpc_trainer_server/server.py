import grpc
from concurrent import futures
from datetime import datetime
import uuid

import trainer_pb2
import trainer_pb2_grpc
from google.protobuf.timestamp_pb2 import Timestamp

# Simulación de base de datos en memoria
TRAINERS_DB = {}


class TrainerServiceServicer(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        print(f"Petición recibida para el trainer con ID: {request.id}")

        # Timestamp para birthdate
        birthdate = Timestamp()
        birthdate.FromDatetime(datetime(1990, 5, 20))

        # Timestamp para created_at
        created_at = Timestamp()
        created_at.FromDatetime(datetime(2023, 1, 1))

        medals = [
            trainer_pb2.Medals(region="Kanto", type=trainer_pb2.MedalType.GOLD),
            trainer_pb2.Medals(region="Johto", type=trainer_pb2.MedalType.SILVER),
        ]

        return trainer_pb2.TrainerResponse(
            id=request.id,
            name="Ash Ketchum",
            birthdate=birthdate,
            medals=medals,
            created_at=created_at
        )

    def GetTrainerById(self, request, context):
        trainer_id = request.id
        print(f"GetTrainerById solicitado para ID: {trainer_id}")
        trainer = TRAINERS_DB.get(trainer_id)
        if not trainer:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details('Trainer not found')
            return trainer_pb2.TrainerResponse()

        return trainer_pb2.TrainerResponse(
            id=trainer["id"],
            name=trainer["name"],
            birthdate=trainer["birthdate"],
            medals=trainer["medals"],
            created_at=trainer["created_at"]
        )

    def CreateTrainer(self, request, context):
        print(f"CreateTrainer solicitado para: {request.name}")

        # Verificamos que no exista un trainer con el mismo nombre (opcional)
        for t in TRAINERS_DB.values():
            if t["name"].lower() == request.name.lower():
                context.set_code(grpc.StatusCode.ALREADY_EXISTS)
                context.set_details('Trainer already exists with that name')
                return trainer_pb2.TrainerResponse()

        trainer_id = str(uuid.uuid4())  # ID único
        now = Timestamp()
        now.GetCurrentTime()

        new_trainer = {
            "id": trainer_id,
            "name": request.name,
            "birthdate": request.birthdate,
            "medals": request.medals,
            "created_at": now
        }

        TRAINERS_DB[trainer_id] = new_trainer

        return trainer_pb2.TrainerResponse(
            id=trainer_id,
            name=request.name,
            birthdate=request.birthdate,
            medals=request.medals,
            created_at=now
        )

    def GetTrainersByName(self, request, context):
        print(f"GetTrainersByName solicitado para nombre: {request.name}")
        name = request.name.lower()
        trainers = []
        for trainer in TRAINERS_DB.values():
            if trainer["name"].lower() == name:
                trainers.append(trainer_pb2.TrainerResponse(
                    id=trainer["id"],
                    name=trainer["name"],
                    birthdate=trainer["birthdate"],
                    medals=trainer["medals"],
                    created_at=trainer["created_at"]
                ))
        if not trainers:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details('No trainers found with that name')
            return trainer_pb2.TrainersListResponse()
        return trainer_pb2.TrainersListResponse(trainers=trainers)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerServiceServicer(), server)
    server.add_insecure_port('[::]:50051')
    print("Servidor gRPC corriendo en el puerto 50051...")
    server.start()
    server.wait_for_termination()


if __name__ == "__main__":
    serve()
