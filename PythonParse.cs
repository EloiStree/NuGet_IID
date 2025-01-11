// namespace NuGet_IID;

// public class SendUdpIID
// {

// }


// # https://buymeacoffee.com/apintio

// import re
// import struct
// import random
// import socket
// import threading
// import websockets
// import asyncio
// import time
// import ntplib

// ####### IID ###

namespace Eloi.IID
{

// ## Websocket IID
// ### SEND WEBSOCKET IID         
// # NOT TESTED YET
// class NoAuthWebsocketIID:
    
//     def __init__(self, ivp4, port):
//         self.ivp4 = IIDUtility.get_ipv4(ivp4)
//         self.port = port
//         self.uri = f"ws://{self.ivp4}:{self.port}"
//         self.on_receive_integer = None
//         self.on_receive_index_integer = None
//         self.on_receive_index_integer_date = None
//         self.loop = asyncio.get_event_loop()
//         self.loop.run_until_complete(self.connect())
        
//     async def connect(self):
//         async with websockets.connect(self.uri) as websocket:
//             await self.listen(websocket)
            
//     async def listen(self, websocket):
//         async for message in websocket:
//             data = message.encode('latin1')
//             size = len(data)
//             if size == 4:
//                 value = IIDUtility.bytes_to_int(data)
//                 if self.on_receive_integer:
//                     self.on_receive_integer(value)
//             elif size == 8:
//                 index, value = IIDUtility.bytes_to_index_integer(data)
//                 if self.on_receive_index_integer:
//                     self.on_receive_index_integer(index, value)
//             elif size == 12:
//                 index, value, date = IIDUtility.bytes_to_index_integer_date(data)
//                 if self.on_receive_index_integer_date:
//                     self.on_receive_index_integer_date(index, value, date)
//             elif size == 16:
//                 index, value, date = IIDUtility.bytes_to_index_integer_date(data)
//                 if self.on_receive_index_integer_date:
//                     self.on_receive_index_integer_date(index, value, date)
            
//  # ## Websocket IID
// ### RECEIVE WEBSOCKET ECHO IID
// # NOT TESTED YET
// class NoAuthServerWebSocketEchoIID:
//     def __init__(self, ivp4:str, port:int, bool_print_debug:bool):
//         self.ivp4 = IIDUtility.get_ipv4(ivp4)
//         self.port = port
//         self.bool_print_debug = bool_print_debug
//         self.uri = f"ws://{self.ivp4}:{str(self.port)}"
//         if self.bool_print_debug:
//             print (f"Websocket IID Echo Server: {self.uri}")
//         self.loop = asyncio.get_event_loop()
//         self.loop.run_until_complete(self.start_server())

//     async def start_server(self):
//         async with websockets.serve(self.echo, self.ivp4, self.port):
//             await asyncio.Future()  # run forever

//     async def echo(self, websocket, path):
//         if self.bool_print_debug:
//             print (f"Websocket IID Echo Server: {self.uri} connected")
//         async for message in websocket:
//             size = len(message)
//             if size == 4 or size == 8 or size == 12 or size == 16:
//                 if self.bool_print_debug:
//                     print (f"Received: {message}")
//                 await websocket.send(message)
                




// """
// python -m build
// pip install .\dist\iid42-2025.1.8.2-py3-none-any.whl --force-reinstall

// pip install --upgrade twine
// python -m twine upload dist/*
// pip install iid42 --force-reinstall

// """


// class HelloWorldIID:
//     def hello_world():
//         print("Hello, World!")
        
//     def push_my_first_iid():
//         print("Push My First IID")
//         target = SendUdpIID("127.0.0.1",3615,True)
//         target.push_integer(42)
//         target.push_index_integer(0,2501)
//         target.push_index_integer_date_ntp_now(1,1001)
//         target.push_index_integer_date_ntp_in_milliseconds(2,2001,1000)
        
        
//     def console_loop_to_push_iid_with_params(ivp4:str, port:int):
//         print("Console Loop To Push IID")
//         target= SendUdpIID(ivp4, port,True)
//         print ("Enter 'exit' to stop")
//         print ("i: 42 (For integer)")
//         print ("ii: 0, 42 (For index integer)")
//         print ("iid: 5, 1000, 50 (Push inex 5 integer 1000 to press with a delay request of 50ms)")
//         print ("iid: 5, 2000, 500 (Push inex 5 integer 2000 to release with a delay request of 500ms)")
        
//         while True:
//             text= input("Enter IID Text: ")
//             target.push_integer_as_shorcut(text)    
        
//     def console_loop_to_push_iid_local():
//         HelloWorldIID.console_loop_to_push_iid_with_params("127.0.0.1",3615)
        
//     def console_loop_to_push_iid_ddns(target_ddns:str):
//         port = 3615
//         ipv4 = socket.gethostbyname(target_ddns)
//         HelloWorldIID.console_loop_to_push_iid_with_params(ipv4,port)
        
    
//     def console_loop_to_push_iid_apintio():
//         """
//         This allows to twitch play in python when EloiTeaching is streaming with UDP activated.
        
//         """
//         # NOTE: UDP on APINT.IO is only available on port 3615 when a Twitch Play is occuring
//         # See Py Pi apintio for ddns name and tools
//         HelloWorldIID.console_loop_to_push_iid_ddns("apint-gaming.ddns.net")
//         // See no-ip.com for creating a ddns name for your own IP address


// if __name__ == "__main__":

//     NtpOffsetFetcher.set_global_ntp_offset_in_milliseconds()
//     offset= NtpOffsetFetcher.get_global_ntp_offset_in_milliseconds()
//     print (f"Default Global NTP Offset: {offset}")

//     bool_loop_listener_test = False
//     if bool_loop_listener_test:
//         print("Loop Listener Test")
//         target = ListenUdpIID("0.0.0.0",3615, offset)
      
    


//     bool_console_test = False
//     if bool_console_test : 
//         print("Console Test")      
//         HelloWorldIID.push_my_first_iid()
//         HelloWorldIID.console_loop_to_push_iid_apintio()
        
//     bool_queue_test = False
//     if bool_queue_test:
//         print("Queue Test")
//         server_name= "apint.ddns.net"
//         server_name= "127.0.0.1"
//         target = SendUdpIID(server_name,3615,True,True)
//         print("IVP4", target.ivp4)
//         while True:
//             target.push_index_integer_in_queue(1,1082,0)
//             target.push_index_integer_in_queue(1,2082,1000)
//             target.push_index_integer_in_queue(1,1037,2000)
//             target.push_index_integer_in_queue(1,2037,4000)
//             target.push_index_integer_in_queue(1,1038,5000)
//             target.push_index_integer_in_queue(1,2038,6000)
//             target.push_index_integer_in_queue(1,1039,7000)
//             target.push_index_integer_in_queue(1,2039,8000)
            
//             target.push_integer_in_queue(2082,11000)
//             target.push_integer_in_queue(1037,12000)
//             target.push_integer_in_queue(2037,14000)
//             target.push_integer_in_queue(1038,15000)
//             target.push_integer_in_queue(2038,16000)
//             target.push_integer_in_queue(1039,17000)
//             target.push_integer_in_queue(2039,18000)
//             time.sleep(5)
            
//     bool_queue_test_ntp=True
//     if bool_queue_test_ntp:
//         print("Queue Test NTP")
//         server_name= "apint.ddns.net"
//         server_name= "127.0.0.1"
//         target = SendUdpIID(server_name,3615,True,True)
//         while True:
//             target.push_index_integer_date_ntp_in_milliseconds(1,1259,5000)
//             for i in range(0, 10):
//                 target.push_index_integer_date_ntp_in_milliseconds(1,i,0)
//                 time.sleep(1)
            
        
    
//     while(True):
//         text = input("Enter IID Text: ")
//         if text == "exit":
//             break   
}