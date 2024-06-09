START ../../PacketGenerator/bin/Debug/PacketGenerator.exe ../../PacketGenerator/PDL.xml
COPY /Y GenPackets.cs "../../DummyClient/Packet/GenPackets.cs"
COPY /Y GenPackets.cs "../../Server/Packet/GenPackets.cs"