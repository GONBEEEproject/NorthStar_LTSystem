using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

namespace GON.TelloControll
{
    public class Controller
    {
        private string host = "192.168.10.1";
        private int port = 8889;
        private UdpClient client;

        public void Initialize()
        {
            if (client == null)
            {
                client = new UdpClient();
            }
            client.Connect(host, port);
        }

        public void Connect()
        {
            byte[] dgram = Encoding.UTF8.GetBytes("command");
            client.Send(dgram, dgram.Length);
            Debug.Log("entry SDK mode");
        }

        public void Takeoff()
        {
            byte[] dgram = Encoding.UTF8.GetBytes("takeoff");
            client.Send(dgram, dgram.Length);
            Debug.Log("Tello auto takeoff");
        }

        public void Land()
        {
            byte[] dgram = Encoding.UTF8.GetBytes("land");
            client.Send(dgram, dgram.Length);
            Debug.Log("Tello auto land");
        }

        public void Emergency()
        {
            byte[] dgram = Encoding.UTF8.GetBytes("emergency");
            client.Send(dgram, dgram.Length);
            Debug.Log("Stop all motors immediately");
        }

        public void SetSpeed(int speed)
        {
            if (speed < 10)
            {
                speed = 10;
            }
            if (speed > 100)
            {
                speed = 100;
            }

            byte[] dgram = Encoding.UTF8.GetBytes("speed " + speed.ToString());
            client.Send(dgram, dgram.Length);
            Debug.Log("set speed to x cm/s");
        }

        public void Forward(int move)
        {
            if (move <= -100)
            {
                move = -100;
            }
            if (move >= 100)
            {
                move = 100;
            }

            byte[] dgram = Encoding.UTF8.GetBytes("rc 0 "+move.ToString()+" 0 0");
            client.Send(dgram, dgram.Length);
            Debug.Log("move foward");
        }

        public void Right(int move)
        {
            if (move <= -100)
            {
                move = -100;
            }
            if (move >= 100)
            {
                move = 100;
            }

            byte[] dgram = Encoding.UTF8.GetBytes("rc " + move.ToString() + " 0 0 0");
            client.Send(dgram, dgram.Length);
            Debug.Log("right");
        }

        public void Down(int move)
        {
            if (move <= -100)
            {
                move = -100;
            }
            if (move >= 100)
            {
                move = 100;
            }

            byte[] dgram = Encoding.UTF8.GetBytes("rc 0 0 " + move.ToString() + " 0");
            client.Send(dgram, dgram.Length);
            Debug.Log("down");
        }
    }
}
