using System;

namespace com.tiger.ian.Utility
{
    public static class GuidHelper
    {
        public static long ToInt64(this Guid g)
        {
            byte[] buffer = g.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
