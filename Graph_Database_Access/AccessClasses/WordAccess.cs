using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Graph_Database_Access.AccessClasses;
using Common.Utilities;
using SQL_Database_Access;

namespace Graph_Database_Access
{
    public class WordAccess : BaseAccess<Word>, IGDBAccess<Word>
    {
        public bool exciteNode(NodeReference<Word> nodeRef, int exitationAmoun)
        {
            throw new NotImplementedException();
        }

        public bool exciteNode(Word node, int exitationAmoun)
        {
            throw new NotImplementedException();
        }

        public List<NodeReference> getChildNodes(NodeReference<Word> nodeRef)
        {
            throw new NotImplementedException();
        }

        public Word GetObject(object value)
        {


            var result =
              client.Cypher.Match("(word:Word)")
                  .Where((Word word) => word.word == (string)value)
                  .Return(word => word.As<Word>())
                  .Results
                  .Single();
            return result;
        }

        public NodeReference<Word> InsertNewWord(string wrd)
        {
            WordDataWebUtility wwl = new WordDataWebUtility();
            WordLogic wl = new WordLogic();
            PartOfSpeechLogic pl = new PartOfSpeechLogic();
            var wordData = wwl.GetWord(wrd);
            var wordSQLPOS = pl.GetPOSbyWord(wrd);
            if (wordData != null)
            {
                foreach (var wd in wordData)
                {
                    wordSQLPOS.AddRange(wd.partOfSpeech);

                }
            }
            Word word = new Word();
            word.partOfSpeech = wordSQLPOS;
            word.word = wrd;


            return InsertNode(word);
        }

        public NodeReference<Word> InsertNode(Word myWord)
        {

            var myNodeReference = client.Create(myWord);
            PhraseAccess pa = new PhraseAccess();
            var phrasenode = pa.InsertNode(pa.GetObject(myWord.word));

            return myNodeReference;
        }
    }
}
