using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 오버라이딩 봉인하기
 * 
 * 기존에 클래스를 상속이 안 되도록 봉인하는 것처럼 메소드도 오버라이딩 되지 않도록 sealed 키워드를 이용해서 봉인할 수 있다.
 * 
 * 모든 메소드를 봉인할 수 있는 것은 아니고, virtual로 선언된 가상 메소드를 오버라이딩한 버전의 메소드만 가능하다.
 * 
 * 등장 배경
 * 오버라이딩을 원치 않으면 virtual 키워드를 붙여주지 않으면 되긴 하지만,
 * 문제는 오버라이딩한 메소드를 막을 수가 없기 때문에 오버라이딩한 메소드에 브레이크인 sealed 키워드가 필요한 것이다.
 */

namespace ConsoleApp4.Class_7
{
    class Base
    {
        public virtual void SealMe()
        {

        }
    }

    class Derived : Base
    {
        public sealed override void SealMe()
        {
      
        }
    }

    class WantToOverride : Derived
    {
        //error
        //public override void SealMe()
        //{

        //}
    }

    class Program
    {
        static void Main()
        {

        }
    }
}
