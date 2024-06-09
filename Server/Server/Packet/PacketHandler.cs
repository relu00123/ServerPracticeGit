using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
     class PacketHandler
    {
        // 패킷이 다 조립되면 무엇을 할 것인가?'

        public static void PlayerInfoReqHandler(PacketSession session, IPacket packet)
        {
            PlayerInfoReq p = packet as PlayerInfoReq;

            Console.WriteLine($"Player InfoReq: {p.playerId} {p.name}");

            foreach (PlayerInfoReq.Skill skill in p.skills)
            {
                Console.Write($"Skill({skill.id})({skill.level})({skill.duration})");
            }
        }

    }
}
