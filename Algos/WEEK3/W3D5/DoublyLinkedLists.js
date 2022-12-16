class ListNode {

    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class DoublyLinkedList {
    constructor() {
        this.head = null;
        this.tail = null;
    }

    /**
     * Inserts a new node with the given newVal after the node that has the
     * given targetVal as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} targetVal The node data to find.
     * @param {any} newVal Data for the new node.
     * @returns {boolean} Indicates if the new node was added.
     */
    insertAfter(targetVal, newVal) {
        let current = this.head;
        while (current) {
            if (current.data === targetVal) {
                // Create the new node and set its next and prev properties.
                const newNode = new ListNode(newVal);
                newNode.prev = current;
                newNode.next = current.next;

                // Update the next and prev properties of the adjacent nodes.
                if (current.next) {
                    current.next.prev = newNode;
                }
                current.next = newNode;

                // If the new node is being inserted after the tail, update the tail.
                if (current === this.tail) {
                    this.tail = newNode;
                }

                return true;
            }
            current = current.next;
        }
        return false;
    }


    /**
     * Inserts a new node with the given newVal before the node that has the
     * given targetVal as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} targetVal The node data to find.
     * @param {any} newVal Data for the new node.
     * @returns {boolean} Indicates if the new node was added.
     */
    insertBefore(targetVal, newVal) {
        let current = this.head;
        while (current) {
            if (current.data === targetVal) {
                // Create the new node and set its next and prev properties.
                const newNode = new ListNode(newVal);
                newNode.prev = current.prev;
                newNode.next = current;

                // Update the next and prev properties of the adjacent nodes.
                if (current.prev) {
                    current.prev.next = newNode;
                }
                current.prev = newNode;

                // If the new node is being inserted before the head, update the head.
                if (current === this.head) {
                    this.head = newNode;
                }

                return true;
            }
            current = current.next;
        }
        return false;
    }

    insertAtFront(data) {
        const newHead = new ListNode(data);

        if (this.isEmpty()) {
            this.head = newHead;
            this.tail = newHead;
        } else {
            const oldHead = this.head;
            oldHead.prev = newHead;
            newHead.next = oldHead;
            this.head = newHead;
        }
        return this;
    }

    insertAtFront2(data) {
        const newHead = new ListNode(data);

        if (this.isEmpty()) {
            this.head = newHead;
            this.tail = newHead;
            return this;
        }

        this.head.prev = newHead;
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }

    insertAtBack(data) {
        const newTail = new ListNode(data);

        if (this.isEmpty()) {
            this.head = newTail;
            this.tail = newTail;
        } else {
            this.tail.next = newTail;
            newTail.prev = this.tail;

            this.tail = newTail;
        }
        return this;
    }

    removeMiddleNode() {
        // when there is only 1 node, it is the middle, remove it.
        if (!this.isEmpty() && this.head === this.tail) {
            const removedData = this.head.data;
            this.head = null;
            this.tail = null;
            return removedData;
        }

        let forwardRunner = this.head;
        let backwardsRunner = this.tail;

        while (forwardRunner && backwardsRunner) {
            if (forwardRunner === backwardsRunner) {
                const midNode = forwardRunner;
                midNode.prev.next = midNode.next;
                midNode.next.prev = midNode.prev;
                return midNode.data;
            }

            if (forwardRunner.prev === backwardsRunner) {
                return null;
            }

            forwardRunner = forwardRunner.next;
            backwardsRunner = backwardsRunner.prev;
        }
        return null;
    }

    isEmpty() {
        return this.head === null;
    }

    toArray() {
        const vals = [];
        let runner = this.head;

        while (runner) {
            vals.push(runner.data);
            runner = runner.next;
        }
        return vals;
    }

    insertAtBackMany(items = []) {
        items.forEach((item) => this.insertAtBack(item));
        return this;
    }

    printValues() {
        let output = '< ';
        let runner = this.head;
        while (runner.next) {
            output += `${runner.data} >< `
            runner = runner.next;
        }
        output += `${runner.data} >`
        console.log(output);
        return this;
    }
}

const emptyList = new DoublyLinkedList();
emptyList.insertAtFront(3);
emptyList.insertAtFront(2);
emptyList.insertAtFront(1);
emptyList.insertBefore(1, 0)
console.log("\nInsert Before:")
emptyList.printValues();


const singleNodeList = new DoublyLinkedList();
singleNodeList.insertAtBack(1);
singleNodeList.insertAtBack(2);
singleNodeList.insertAtBack(3);
singleNodeList.insertAfter(3, 4);
console.log("\nInsert After:")
singleNodeList.printValues();

/**************** Uncomment these test lists after insertAtBack is created. ****************/
// const singleNodeList = new DoublyLinkedList().insertAtBack(1);
// const biNodeList = new DoublyLinkedList().insertAtBack(1).insertAtBack(2);
// const firstThreeList = new DoublyLinkedList().insertAtBackMany([1, 2, 3]);
// const secondThreeList = new DoublyLinkedList().insertAtBackMany([4, 5, 6]);
// const unorderedList = new DoublyLinkedList().insertAtBackMany([
//   -5,
//   -10,
//   4,
//   -3,
//   6,
//   1,
//   -7,
//   -2,
// ]);