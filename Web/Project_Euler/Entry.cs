/*
 * @project Project_Euler
 * @see https://projecteuler.net/archives
 *  ~kr : 이 프로젝트의 소스는 상기의 사이트의 알고리즘의 문제를 기준으로 일부 수정하여 작성되었습니다.
 *        Ask () 함수에 작성한 텍스트는 원문을 인용하였습니다.
 *  ~jp : このプロジェクトのソースは、上記のサイトのアルゴリズムの問題に基づいて、いくつかの修正して作成されました。
 *        Ask（）関数に作成したテキストは、原文を引用しました。
 */

namespace Project_Euler
{
    class Entry
    {
        static void Main(string[] args)
        {
            var question = new Q007_Nth_prime();

            if (question.Ask())
                question.Answer(question.Arguments);
        }
    }
}
