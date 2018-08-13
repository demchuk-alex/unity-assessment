using System;
using System.Text;

namespace Common.Structures
{
    public class CustomLinkedList
    {
        #region Properties

        public ListNode Head { get; set; }

        #endregion

        #region Methods

        public void AddSorted(ListNode newNode)
        {
            if (Head == null || Head.Data >= newNode.Data)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next != null && current.Next.Data < newNode.Data)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public override string ToString()
        {
            if (Head == null) return "List is empty";
            var sb = new StringBuilder();
            var temp = Head;
            while (temp != null)
            {
                sb.Append($"{temp.Data} ");
                temp = temp.Next;
            }
            return sb.ToString();
        }

        #endregion
    }
}
