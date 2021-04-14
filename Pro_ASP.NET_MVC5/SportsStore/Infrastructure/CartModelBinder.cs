using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Infrastructure
{
    /*
     * 사용자 지정 모델 바인더 생성 ;
     * MVC 프레임워크는 사용자 지정 바인더와 기본 바인더를 사용해서 액션 메서드에 필요한 일련의 매개변수들을 생성할 수 있음
     * - 컨트롤러에서 Cart 개체 생성 방법을 알 필요가 없을 때 사용자 지정 모델 바인더 생성으로 리팩터링 가능
     * 
     * 
     * 참고1) MVC 프레임워크의 폼 처리 방식 ;
     *       - MVC 프레임워크는 먼저 대상 액션 메서드의 매개변수들을 확인함
     *       - 모델 바인더를 사용하여 브라우저가 보낸 폼의 값들과 매개변수를 비교함
     *       - 만약 같은 이름을 가진 폼 값들이 있으면, 해당 폼 값들을 액션 메서드에 전달하기 전에 매개변수의 형식으로 변환하여 전달함
     *       
     * --> 사용자 지정 모델 바인더를 통해 컨트롤러 마다 Session 이 존재하는지 확인하고 생성하는 중복 처리를 제거하며 분리 할 수 있음 
     * 
     * 참고2) 사용자 지정 모델 바인더 처리 방식 ;
     *        - MVC 프레임워크는 Cart 개체가 필요하다는 요청을 받으면 (AddToCart 메서드가 호출되면),
     *        - 먼저 액션 메서드의 매개변수들을 확인
     *        - 그런 다음, 사용 가능한 바인더들의 목록을 살펴 봄 (Global.asax.cs 의 ModelBinders 에 추가되어 있는 목록 확인)
     *        - 액션 메서드의 매개변수에 해당하는 인스턴스를 생성할 수 있는 바인더를 찾으면,
     *        - IModelBinder 인터페이스를 구현한 ModelBinder 클래스를 통해 매개변수 인스터스가 생성되어 액션 메서드로 전달됨 
     * 
     * 장점1) Cart 개체를 생성하는 로직을 컨트롤러로 부터 분리함. (상황에 따라 자유롭게 Cart 개체를 저장하는 방식을 변경할 수도 있음)
     * 장점2) Cart 개체가 필요한 다른 컨트롤러에서도 간단히 매개변수만 추가하여 사용가능함
     * 장점3) 단위 테스트가 가능
     * 
     */
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // 세션에서 Cart 개체 가져오기
            Cart cart = null;
            if(controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            // 세션 데이터에 Cart 개체가 없다면 새로 생성한다.
            if(cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // Cart 개체를 반환한다.
            return cart;
        }
    }
}