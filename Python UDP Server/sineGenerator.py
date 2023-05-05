import math
import socket
import struct
import time

UDP_IP = "127.0.0.1"
UDP_PORT = 5005
MESSAGE_INTERVAL = 0.01  # interval between sending messages (in seconds)
FREQUENCY = 10
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

t = 0
while True:
    sine = math.sin(2*math.pi*FREQUENCY*t)
    mapped_value = str(((sine + 1) / 2) * 99 + 1)
    data = bytes(mapped_value, 'utf-8')
    print(data)
    sock.sendto(data, (UDP_IP, UDP_PORT))
    t += MESSAGE_INTERVAL
    time.sleep(MESSAGE_INTERVAL)
