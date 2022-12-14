/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
        this.items.push(item);
        return this.size();
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        return this.items.shift();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length === 0;
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
        return this.items.length;
    }

    print() {
        const str = this.items.join(" ");
        console.log(str);
        return str;
    }

    /**
   * Compares this queue to another given queue to see if they are equal.
   * Avoid indexing the queue items directly via bracket notation, use the
   * queue methods instead for practice.
   * Use no extra array or objects.
   * The queues should be returned to their original order when done.
   * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
   *     array queue being O(n).
   * - Space: O(1) constant.
   * @param {Queue} q2 The queue to be compared against this queue.
   * @returns {boolean} Whether all the items of the two queues are equal and
   *    in the same order.
   */
    compareQueues(q2) {
        if(this.isEmpty() && q2.isEmpty())
        {
            return true;
        }
        if(this.items.length != q2.items.length)
        {
            return false;
        }
        for(let i = 0; i < this.items.length; i++)
        {
            if(this.items[i] != q2.items[i])
            {
                return false;
            }
        }
        return true;
    }

    /**
   * Determines if the queue is a palindrome (same items forward and backwards).
   * Avoid indexing queue items directly via bracket notation, instead use the
   * queue methods for practice.
   * Use only 1 stack as additional storage, no other arrays or objects.
   * The queue should be returned to its original order when done.
   * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
   *     array queue being O(n).
   * - Space: O(n) from the stack being used to store the items again.
   * @returns {boolean}
   */
    isPalindrome() {
        let newQueue = new Queue();
        newQueue.items = [...this.items.reverse()];
        console.log(this.items);
        console.log(newQueue.items);
        this.compareQueues(newQueue);
    }
}

let myQueue = new Queue();
let myQueue2 = new Queue();
myQueue.enqueue(100);
myQueue.enqueue(12);
myQueue.enqueue(1);
myQueue.enqueue(45);
myQueue2.enqueue(0);
myQueue2.enqueue(12);
myQueue2.enqueue(1);
myQueue2.enqueue(45);
console.log(myQueue2.isPalindrome());
// console.log(myQueue.compareQueues(myQueue2));







/* EXTRA: Rebuild the above class using a linked list instead of an array. */

/* 
    In order to maintain an O(1) enqueue time complexity like .push with an array
    We add a tail to our linked list so we can go directly to the last node
*/

// class QueueNode {
//     constructor(data) {
//         this.data = data;
//         this.next = null;
//     }
// }

// class LinkedListQueue {
//     constructor() {
//         this.head = null;
//         this.tail = null;
//         this.size = 0;
//     }

//     /**
//      * - Time: O(1) constant.
//      * - Space: O(1) constant.
//      * @returns {boolean} Indicates if the list is empty.
//      */
//     isEmpty() {
//         return this.head === null;
//     }

//     /**
//      * Adds a given val to the back of the queue.
//      * - Time: O(1) constant.
//      * - Space: O(1) constant.
//      * @param {any} val
//      * @returns {number} The new size of the queue.
//      */
//     enqueue(val) {
//         const newTail = new QueueNode(val);

//         if (this.isEmpty()) {
//             this.head = newTail;
//             this.tail = newTail;
//         } else {
//             this.tail.next = newTail;
//             this.tail = newTail;
//         }
//         // pre-increment so the new size is returned otherwise old size is returned
//         return ++this.size;
//     }

//     /**
//      * - Time: O(1) constant.
//      * - Space: O(1) constant.
//      * @returns {any} The removed item.
//      */
//     dequeue() {
//         // remove head
//         if (!this.head) {
//             return null;
//         }

//         const dequeued = this.head;
//         this.head = this.head.next;

//         if (this.head === null) {
//             this.tail = null;
//         }

//         this.size--;
//         return dequeued.data;
//     }

//     /**
//      * Retrieves the first item without removing it.
//      * - Time: O(1) constant.
//      * - Space: O(1) constant.
//      * @returns {any} The first item.
//      */
//     front() {
//         return this.head ? this.head.data : null;
//     }

//     /**
//      * Determines if the given item is in the queue.
//      * - Time: O(n) linear.
//      * - Space: O(1) constant.
//      * @param {any} searchVal
//      * @returns {boolean}
//      */
//     contains(searchVal) {
//         let runner = this.head;

//         while (runner) {
//             if (runner.searchVal === searchVal) return true;
//             runner = runner.next;
//         }
//         return false;
//     }
// }