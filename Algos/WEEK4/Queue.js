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
        this.items = [item, ...this.items]
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        return this.items.pop();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[this.size() - 1];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.size() === 0;
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
}

/* EXTRA: Rebuild the above class using a linked list instead of an array. */

/* 
    In order to maintain an O(1) enqueue time complexity like .push with an array
    We add a tail to our linked list so we can go directly to the last node
*/

class QueueNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class LinkedListQueue {
    constructor() {
        this.top = null;
        this.tail = null;
        this.size = 0;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean} Indicates if the list is empty.
     */
    isEmpty() {
        return this.size === 0;
    }

    /**
 * Adds a given val to the back of the queue.
 * - Time: O(1) constant.
 * - Space: O(1) constant.
 * @param {any} val
 * @returns {number} The new size of the queue.
 */
    enqueue(val) {
        // Create a new node with the given data
        const newNode = new QueueNode(val);

        // If the queue is empty, set the top and tail to the new node
        if (this.isEmpty()) {
            this.top = newNode;
            this.tail = newNode;
        } else {
            // Otherwise, set the new node as the next of the current tail and update the tail
            this.tail.next = newNode;
            this.tail = newNode;
        }

        // Increment the size of the queue and return the new size
        this.size++;
        return this.size;
    }


    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item.
     */
    dequeue() {
        if (this.isEmpty()) {
            return null;
        }
        let removed = this.top;
        this.size--;
        if (this.size === 1) {
            this.tail = null;
            this.top = null;
            return removed;
        }
        this.top = this.top.next;
        return removed;
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item.
     */
    front() {
        return this.isEmpty() ? null : this.top.data;
    }

    /**
     * Determines if the given item is in the queue.
     * - Time: O(n) linear.
     * - Space: O(1) constant.
     * @param {any} searchVal
     * @returns {boolean}
     */
    contains(searchVal) {
        // if(this.isEmpty())
        // {
        //     return null;
        // }
        let runner = this.top;

        while (runner) {
            if (runner.data === searchVal) {
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    toArr() {
        const arr = [];
        let runner = this.top;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}


let firstQueue = new Queue();
firstQueue.enqueue(5);
firstQueue.enqueue(10);
firstQueue.enqueue(1);
firstQueue.enqueue(25);
// console.log(firstQueue.dequeue());
// console.log(firstQueue.items);
// console.log(firstQueue.front());
// console.log(firstQueue.isEmpty());


let firstList = new LinkedListQueue();
firstList.enqueue(100);
firstList.enqueue(1);
firstList.enqueue(50);
firstList.enqueue(25);
// firstList.dequeue();
// console.log(firstList.contains(1));
// console.log(firstList.front());
console.log(firstList.toArr());
// console.log(firstList.isEmpty());

