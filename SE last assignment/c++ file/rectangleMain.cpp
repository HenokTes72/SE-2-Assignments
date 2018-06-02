#include <iostream>
#include "first.h"

using namespace std;

int main(){
	
	Rectangle box;
	double boxLength,boxWidth;
	
	// Get box length and width
	cout << "This program will calculate the area of a rectangle. \n";
	cout << "Enter a length: ";
	cin >> boxLength;
	cout << "Enter a width: ";
	cin >> boxWidth;
	
	if(!box.setLength(boxLength)){
		cout << "Invalid box length entered. \n";
	}
	else if(!box.setWidth(boxWidth)){
		cout << "Invalid box width entered. \n";
	}
	else{
		cout << "\nHere is the rectangle's data:\n";
		cout << "Length: " << box.getLength() << endl;
		cout << "Width: " << box.getWidth() << endl;
		cout << "Area: " << box.getArea() << endl;
	}
	

	return 0;
}


