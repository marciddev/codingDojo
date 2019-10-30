function binarySearch(arr, val) {
  var high = arr.length-1;
  var low = 0;
  var mid = (low+high)/2
  while(low <= high) {
    if(val == arr[mid]) {
      return mid;
    }
    if(val > arr[mid]) {
      low = mid + 1;
      console.log("high is " + high + " and low is " + low + " and mid is " + mid)
    }
    if(val < arr[mid]) {
      high = mid - 1;
      console.log("high is " + high + " and low is " + low + " and mid is " + mid)
    }
  }
  return -1;
}
document.write(binarySearch([1,2,3,4,5,6,7], 1));