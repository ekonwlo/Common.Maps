using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Math = System.Math;

namespace Common.Maps.Utils
{
    public static class EncodedPolyline
    {
        public static string Encode(double value)
        {

            //Dim v1 As Int32 = Round(Value * 100000)
            //Dim v2 As UInt32 = UInt32.MaxValue
            int v1 = (int)Math.Round(value * 100000);
            uint v2 = uint.MaxValue;

            //If v1 < 0 Then
            //    v2 = (Not UInt32.Parse(Abs(v1))) + 1

            //Else
            //    v2 = v1

            //End If
            if (v1 < 0)
                v2 = ~((uint)Math.Abs(v1)) + 1;
            else
                v2 = (uint) v1;

            //v2 <<= 1
            v2 <<= 1;
            
            //If v1 < 0 Then v2 = Not v2
            if (v1 < 0)
                v2 = ~v2;

            //Dim chunks() As Byte = {v2 << 27 >> 27,
            //                        v2 << 22 >> 27,
            //                        v2 << 17 >> 27,
            //                        v2 << 12 >> 27,
            //                        v2 << 7 >> 27,
            //                        v2 << 2 >> 27}
            byte[] chunks = new byte[]{ (byte) (v2 << 27 >> 27),
                                        (byte) (v2 << 22 >> 27),
                                        (byte) (v2 << 17 >> 27),
                                        (byte) (v2 << 12 >> 27),
                                        (byte) (v2 << 7 >> 27),
                                        (byte) (v2 << 2 >> 27)};

            //Dim skip As Boolean = False
            //Dim take As Byte = 6
            bool skip = false;
            byte take = 6;

            //For i As Int16 = 4 To 0 Step -1

            //    If chunks(i + 1) > 0 Or skip Then
            //        skip = True
            //        chunks(i) += 32
            //    Else
            //        take -= 1
            //    End If
            //Next
            for (int i = 4; i > 0; i--)
            {
                if (chunks[i + 1] > 0 | skip)
                {
                    skip = true;
                    chunks[i] += 32;
                }
                else
                    take--;
            }

            //chunks(0) += 63
            //chunks(1) += 63
            //chunks(2) += 63
            //chunks(3) += 63
            //chunks(4) += 63
            //chunks(5) += 63           
            chunks[0] += 63;
            chunks[1] += 63;
            chunks[2] += 63;
            chunks[3] += 63;
            chunks[4] += 63;
            chunks[5] += 63;
            
            //'Console.WriteLine(Encoding.ASCII.GetString(chunks, 0, take))

            //Return Encoding.ASCII.GetString(chunks, 0, take)
            return Encoding.ASCII.GetString(chunks, 0, take);
        }

    }
}
