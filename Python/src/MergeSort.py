from typing import List

class MergeSort:
    def sort(self, arr: List[int]) -> List[int]:
        self.__sort_recursive(arr, 0, len(arr) - 1)
        return arr

    def __sort_recursive(self, arr: List[int], start: int, end: int) -> None:
        if start >= end: return
        mid = (start + end) // 2 #  (start + end - start) // 2
        self.__sort_recursive(arr, start, mid)
        self.__sort_recursive(arr, mid + 1, end) # // 2 - rounds to smaller, so add 1
        mid = mid + 1
        for i in range(start, mid):
            if arr[i] > arr[mid]: 
                arr[i], arr[mid] = arr[mid], arr[i]
                mid += 1
            if mid > end: break


if __name__ == "__main__":
    ms = MergeSort()
    print(ms.sort([1, 5, 6, 2, 10, 3]))
    print(ms.sort([]))
    print(ms.sort([1]))
    print(ms.sort([1,2]))
    print(ms.sort([2,1]))
    print(ms.sort([3,2,1]))
    print(ms.sort([1,2,3]))