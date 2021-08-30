from typing import List

class QuickSort:
    def sort(self, arr: List[int]) -> List[int]:
        self.__sort_recursive(arr, 0, len(arr) - 1)
        return arr

    def __sort_recursive(self, arr: List[int], start: int, end: int) -> None:
        if (start >= end):
            return
        less = start
        pivot = end
        for i in range(start, end):
            if arr[i] <= arr[pivot]:
                arr[less], arr[i] = arr[i], arr[less]
                less += 1
        arr[less], arr[pivot] = arr[pivot], arr[less]
        self.__sort_recursive(arr, start, less - 1)
        self.__sort_recursive(arr, less + 1, end)


if __name__ == "__main__":
    qs = QuickSort()
    print(qs.sort([1, 5, 6, 2, 10, 3]))
    print(qs.sort([]))
    print(qs.sort([1]))
    print(qs.sort([1,2]))
    print(qs.sort([2,1]))
    print(qs.sort([3,2,1]))
    print(qs.sort([1,2,3]))


    

