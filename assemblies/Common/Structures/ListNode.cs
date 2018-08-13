namespace Common.Structures
{
    public class ListNode
    {
        #region Properties

        public int Data { get; set; }
        public ListNode Next { get; set; }

        #endregion

        public ListNode(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
