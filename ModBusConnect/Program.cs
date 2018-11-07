
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;


namespace ModBusConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            ModbusClient modBusClient = new ModbusClient("127.0.0.1", 502);
            modBusClient.Connect();
            bool[] readCoils = modBusClient.ReadCoils(0, 10);
            int[] readInputRegisters = modBusClient.ReadInputRegisters(0, 10);
            int[] readsHoldingRegisters = modBusClient.ReadHoldingRegisters(0, 10);
            bool[] readDiscreteInputs = modBusClient.ReadDiscreteInputs(0, 10);
            int[] ar = new int[5];
            ar[0] = 1;
            ar[1] = 2;
            ar[2] = 3;
            int[] readMultipleRegisters = modBusClient.ReadWriteMultipleRegisters(0, 10, 0, ar);

            for (int i = 0; i < readCoils.Length; i++)
            {
                Console.WriteLine("Value of Coil :" + (9 + i + 1) + " " + readCoils[i].ToString());
            }

            for (int i = 0; i < readsHoldingRegisters.Length; i++)
            {
                Console.WriteLine("Value of HoldingRegister :" + (9 + i + 1) + " " + readsHoldingRegisters[i].ToString());
            }

            Console.Read();
        }
    }
}
