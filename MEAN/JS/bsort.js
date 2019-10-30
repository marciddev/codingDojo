function bubblesort(arr) {
	for(var i=0;i<arr.length-1;i++) {
		for(var j=0;j<arr.length-1;j++) {
			if(arr[j] > arr[j+1]) {
				//swap the values here
				temp = arr[j];
				arr[j] = arr[j+1];
				arr[j+1] = temp;
			}
		}
	}