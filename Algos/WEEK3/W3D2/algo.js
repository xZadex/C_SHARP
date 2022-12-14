
class MinHeap {
    constructor() {
        this.heap = [null];
    }

    /**
     * Extracts the min num from the heap and then re-orders the heap to
     * maintain order so the next min is ready to be extracted.
     * 1. Save the first node to a temp var.
     * 2. Pop last node off and set idx1 equal to the popped value.
     * 3. Iteratively swap the old last node that is now at idx1 with it's
     *    smallest child IF the smallest child is smaller than it.
     * - Time: O(log n) logarithmic due to shiftDown.
     * - Space: O(1) constant.
     * @returns {?number} The min number or null if empty.
     */
    extract() {
        if (this.heap.length <= 1) {
            return null;
        }

        const min = this.heap[1];
        const last = this.heap.pop();
        if (this.heap.length > 1) {
            this.heap[1] = last;
            let idx = 1;
            let leftChildIdx = 2;
            let rightChildIdx = 3;
            let swapIdx;
            let isHeapValid = false;

            while (!isHeapValid) {
                leftChildIdx = idx * 2;
                rightChildIdx = idx * 2 + 1;

                // Check if there is a left child and if it's smaller than the current node
                if (leftChildIdx <= this.heap.length - 1 && this.heap[leftChildIdx] < this.heap[idx]) {
                    swapIdx = leftChildIdx;
                } else {
                    swapIdx = idx;
                }

                // Check if there is a right child and if it's smaller than the current node
                if (rightChildIdx <= this.heap.length - 1 && this.heap[rightChildIdx] < this.heap[swapIdx]) {
                    swapIdx = rightChildIdx;
                }

                // If the current node is not the smallest of its children, swap it with the smallest
                // and update the index to the position of the swapped node
                if (swapIdx !== idx) {
                    [this.heap[idx], this.heap[swapIdx]] = [this.heap[swapIdx], this.heap[idx]];
                    idx = swapIdx;
                } else {
                    isHeapValid = true;
                }
            }
        }

        return min;
    }

    top() {
        return this.heap.length > 1 ? this.heap[1] : null;
    }

    insert(num) {
        this.heap.push(num);
        this.shiftUp();
        return this.size();
    }

    size() {
        return this.heap.length - 1;
    }

    shiftUp() {
        let idxOfNodeToShiftUp = this.heap.length - 1;

        while (idxOfNodeToShiftUp > 1) {
            const idxOfParent = this.idxOfParent(idxOfNodeToShiftUp);

            const isParentSmallerOrEqual =
                this.heap[idxOfParent] <= this.heap[idxOfNodeToShiftUp];

            if (isParentSmallerOrEqual) {
                break;
            }

            this.swap(idxOfNodeToShiftUp, idxOfParent);
            idxOfNodeToShiftUp = idxOfParent;
        }
    }

    idxOfParent(i) {
        return Math.floor(i / 2);
    }

    idxOfLeftChild(i) {
        return i * 2;
    }

    idxOfRightChild(i) {
        return i * 2 + 1;
    }

    swap(i, j) {
        [this.heap[i], this.heap[j]] = [this.heap[j], this.heap[i]];
    }

    printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
        if (parentIdx > this.heap.length - 1) {
            return;
        }

        spaceCnt += spaceIncr;
        this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${this.heap[parentIdx]} (${parentIdx})`
        );

        this.printHorizontalTree(parentIdx * 2, spaceCnt);
    }
}


let myHeap = new MinHeap();
myHeap.insert(20)
myHeap.insert(50)
myHeap.insert(15)
myHeap.insert(90)
myHeap.insert(42)
myHeap.insert(70)
// myHeap.printHorizontalTree();
console.log(myHeap.extract());
console.log(myHeap.extract());
console.log(myHeap.extract());
console.log("Tree with lowest removed:")
myHeap.printHorizontalTree();