import grpc
from concurrent import futures
from datetime import datetime
import time

import trainer_pb2
import trainer_pb2_grpc
from google.protobuf.timestamp_pb2 import Timestamp


class TrainerServiceServicer(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        print(f"Petición recibida para el trainer con ID: {request.id}")

        # Timestamp para birthdate
        birthdate = Timestamp()
        birthdate.FromDatetime(datetime(1990, 5, 20))

        # Timestamp para created_at
        created_at = Timestamp()
        created_at.FromDatetime(datetime(2023, 1, 1))

        # Hardcodear algunas medallas
        medals = [
            trainer_pb2.Medals(region="Kanto", type=trainer_pb2.GOLD),
            trainer_pb2.Medals(region="Johto", type=trainer_pb2.SILVER),
        ]

        # Respuesta estática
        return trainer_pb2.TrainerResponse(
            id=request.id,
            name="Ash Ketchum",
            age=15,
            birthdate=birthdate,
            medals=medals,
            created_at=created_at
        )


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerServiceServicer(), server)
    server.add_insecure_port('[::]:50051')
    print("Servidor gRPC corriendo en el puerto 50051...")
    server.start()
    server.wait_for_termination()


if __name__ == "__main__":
    serve()
