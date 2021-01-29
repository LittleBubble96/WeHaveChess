using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace BubbleFramework.Sever
{
    public class Sever : MonoBehaviour
    {
        //数据缓冲池
        private byte[] _cache = new byte[1024 * 1024];
        
        //Ip 和 端口
        private IPAddress _iP;

        private int _port;

        private Socket _sever;
        
        public void Init()
        { 
            _iP = IPAddress.Parse("127.0.0.1");
            _port = 8222;
            
            //ipv4 格式的 数据流   TCP 传输模式 
            _sever = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            
        }

        public void DoUpdate(float dt)
        {
            
        }

        private void StartListener()
        {
            
        }
    }

}
