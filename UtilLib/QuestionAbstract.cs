using System;

namespace Algorithms.Internal
{
    /*
     * @class QuestionAbstract<T>
     *  ~kr : 알고리즘 프로젝트 내 각 문제 클래스들의 기본형을 정의한 추상형 클래스입니다.
     *        제네릭 형의 타입은 문제에서 사용하는 매개변수의 타입으로 지정합니다.
     *  ~jp : アルゴリズムのプロジェクト内の各問題のクラスの基本形を定義した抽象型クラスです。
     *        ジェネリック型のタイプは、問題に使うパラメータのタイプで指定します。
     */
    public abstract class QuestionAbstract<T>
        where T : IConvertible, IComparable
    {
        public virtual bool Ask()
        {
            Output.Reset();
            Output.Ask(this);   

            return true;
        }
        public abstract T[] Arguments { get; }
        public abstract void Answer(T[] args);
    }

}
