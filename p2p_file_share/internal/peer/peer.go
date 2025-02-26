package peer

import (
	"bufio"
	"fmt"
	"net"
	"os"
)

func StartListening(port string) {
	listener, err := net.Listen("tcp", ":"+port)
	if err != nil {
		fmt.Println("Error Starting  listening:", err)
		return
	}
	defer listener.Close()
	fmt.Printf("peer is listening on port %v...../n", port)
	for {
		conn, err := listener.Accept()
		if err != nil {
			fmt.Println("Error accepting connection:", err)
			continue
		}
		go handleClient(conn)
		break
	}
}
func DownloadFile(adress string, filepath string, savePath string) {
	conn, err := net.Dial("tcp", adress)
	if err != nil {
		fmt.Println("error conect per to peer:", err)
		return
	}
	defer conn.Close()
	handleDownload(conn, filepath, savePath)
}
func handleDownload(conn net.Conn, filePath string, savePath string) {
	sendMessage(conn, filePath)
	file, err := os.Create(savePath)
	if err != nil {
		fmt.Println("Error creating file:", err)
		return
	}
	defer file.Close()
	reader := bufio.NewReader(conn)
	buffer := make([]byte, 1024)
	for {
		n, err := reader.Read(buffer)
		if err != nil {
			break
		}
		_, err = file.Write(buffer[:n])
		if err != nil {
			fmt.Println("Error writing to file:", err)
			break
		}
	}
	fmt.Println("File downloaded successfully")
}
func handleClient(conn net.Conn) {
	defer conn.Close()
	buf := make([]byte, 1024)
	n, err := conn.Read(buf)
	if err != nil {
		fmt.Println("Connection Lost :(", err)
		return
	}
	fileName := string(buf[:n])
	file, err := os.Open(fileName)
	defer file.Close()
	if err != nil {
		fmt.Println("Sending file to peer")
		sendFile(file, conn)
		return
	} else if os.IsNotExist(err) {
		fmt.Println("File %v does not exist", fileName)
		sendMessage(conn, "File not found")
	} else {
		fmt.Println("Error readin file ", err)
		sendMessage(conn, "ther was an error reading the file ")
	}
}
func sendFile(file *os.File, conn net.Conn) {
	reader := bufio.NewReader(file)
	buffer := make([]byte, 1024)
	for {
		n, err := reader.Read(buffer)
		if err != nil && err.Error() != "EOF" {
			fmt.Println("Error sending file:", err)
			break
		}
		_, err = conn.Write(buffer[:n])
		if err != nil {
			fmt.Println("Error sending file:", err)
			break
		}
		if err == nil && n == 0 {
			break
		}
	}
	fmt.Println("file sent successfully")
}
func sendMessage(conn net.Conn, message string) {
	writer := bufio.NewWriter(conn)
	_, err := writer.WriteString(message)
	if err != nil {
		fmt.Println("Error sending message:", err)
		return
	}
	writer.Flush()
}
