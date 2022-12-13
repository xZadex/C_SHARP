
class MinHeap {
    constructor() {

        this.heap = [null];
    }

    top() {
        return this.heap.length === 1 ? null : this.heap[1];
    }

    last(){
        return this.heap.length === 1 ? null : this.heap[this.heap.length - 1];
    }

    insert(num) {
        this.heap.push(num);

        let index = this.heap.length - 1;
        let parentIndex = Math.floor(index / 2);
        while (index > 1 && this.heap[index] < this.heap[parentIndex]) {
            let temp = this.heap[index];
            this.heap[index] = this.heap[parentIndex];
            this.heap[parentIndex] = temp;
            index = parentIndex;
            parentIndex = Math.floor(index / 2);
        }
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
myHeap.insert(2);
myHeap.insert(10);
myHeap.insert(35);
myHeap.insert(42);
myHeap.insert(12);
myHeap.insert(99);
myHeap.printHorizontalTree();
console.log(myHeap.top());
console.log(myHeap.last());
