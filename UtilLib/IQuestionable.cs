using System;

namespace Algorithms.Internal
{
    /*
     * @interface IQuestionable<T>
     *  ~kr : 알고리즘 프로젝트 내 각 문제 클래스들의 기본형을 정의한 인터페이스입니다.
     *        제네릭 형의 타입은 문제에서 사용하는 매개변수의 타입으로 지정합니다.
     *  ~jp : アルゴリズムのプロジェクト内の各問題のクラスの基本形を定義したインターフェイスです。
     *        ジェネリック型のタイプは、問題に使うパラメータのタイプで指定します。
     */
    public interface IQuestionable<T>
        where T : IConvertible, IComparable
    {
        bool Ask();
        T[] Arguments { get; }
        void Answer(T[] args);
    }

}
