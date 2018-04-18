using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary
{
    [Serializable]
    public class Posts : DictionaryBase
    {
        public Posts()
        {
        }

        public void Add(string pPostID, Post pPost)
        {
            Dictionary.Add(pPostID, pPost);
        }

        public void Remove(string pPostID)
        {
            Dictionary.Remove(pPostID); 
        }

        public Post this[string pPostID]
        {
            get
            {
                return (Post)Dictionary[pPostID];
            }
            set
            {
                Dictionary[pPostID] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object post in Dictionary.Values)
                yield return (Post)post;
        }
    }
}
