using SportsStore.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SportsStore.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            // 사용자가 입력한 자격 증명의 유효성을 검사한다.
            bool result = FormsAuthentication.Authenticate(username, password);
            if(result)
            {
                // 브라우저로 반환하는 응답에 쿠키를 추가하여 사용자가 매번 요청할 때마다 다시 인증을 받을 필요가 없게 해준다.
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }
}