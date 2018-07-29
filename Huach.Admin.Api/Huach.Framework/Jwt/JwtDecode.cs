using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Framework.Jwt
{
    internal class JwtDecode<T>
    {
        public virtual bool IsSucceed
        {
            get
            {
                return this.VerifyResult == JwtVerifyResult.Succeed;
            }
        }
        public JwtVerifyResult VerifyResult { get; set; }
        public string Msg { get; set; }
        public T Payload { get; set; }
    }

    internal enum JwtVerifyResult
    {
        Fail = 1,
        Succeed,
        Expired,
        InvalidSignature
    }
    public enum JwtClaimName
    {
        iss,
        sub,
        aud,
        exp,
        nbf,
        iat,
        jti,
        preferred_username,
        phone_number,
        auth_time
    }
}
