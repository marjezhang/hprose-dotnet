﻿/**********************************************************\
|                                                          |
|                          hprose                          |
|                                                          |
| Official WebSite: http://www.hprose.com/                 |
|                   http://www.hprose.org/                 |
|                                                          |
\**********************************************************/
/**********************************************************\
 *                                                        *
 * NullableSerializer.cs                                  *
 *                                                        *
 * NullableSerializer class for C#.                       *
 *                                                        *
 * LastModified: Mar 30, 2018                             *
 * Author: Ma Bingyao <andot@hprose.com>                  *
 *                                                        *
\**********************************************************/

namespace Hprose.IO.Serializers {
    class NullableSerializer<T> : Serializer<T?> where T : struct {
        public override void Write(Writer writer, T? obj) {
            if (obj.HasValue) {
                Serializer<T>.Instance.Write(writer, obj.Value);
            }
            else {
                writer.Stream.WriteByte(HproseTags.TagNull);
            }
        }
    }
}