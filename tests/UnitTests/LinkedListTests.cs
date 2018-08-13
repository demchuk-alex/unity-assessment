using System;
using System.Collections.Generic;
using System.Linq;
using Common.Structures;
using Xunit;

namespace UnitTests
{
    public class LinkedListTests
    {

        private CustomLinkedList _list;

        public LinkedListTests()
        {
           _list = new CustomLinkedList();

            _list.AddSorted(new ListNode(2));
            _list.AddSorted(new ListNode(4));
            _list.AddSorted(new ListNode(3));
            _list.AddSorted(new ListNode(1));
        }

        [Fact]
        public void CheckIfListIsCorrect()
        {
            var expected = "1 2 3 4 ";
            var actual = _list.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckIntAtSpecificPosition()
        {
            var position = 2;
            var expected = 3;
            var tempPointer = GetValueAtPosition(position);
            var actual = tempPointer.Data;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckIfOrderIsAscending()
        {
            var expectedMin = 1;
            var expectedMax = 4;
            var temp = _list.Head;
            var intList = new List<int>();
            while (temp.Next != null)
            {
                intList.Add(temp.Data);
                temp = temp.Next;
                if (temp.Next == null)
                {
                    intList.Add(temp.Data);
                }
            }

            var min = intList.First();
            var max = intList.Last();

            var orderedAscending = intList.OrderBy(x => x).ToList();

            Assert.Equal(min, expectedMin);
            Assert.Equal(max, expectedMax);

            for (var i = 0; i < orderedAscending.Count; i++)
            {
                Assert.Equal(orderedAscending[i], intList[i]);
            }
        }

        private ListNode GetValueAtPosition(int position)
        {
            var tempPointer = _list.Head;

            var count = 0;
            while (count < position)
            {
                tempPointer = tempPointer.Next;
                count++;
            }
            return tempPointer;
        }
    }
}
