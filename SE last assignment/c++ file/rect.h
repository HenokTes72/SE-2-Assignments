void displayMessage(void);

#ifndef RECTANGLE_H
#define RECTANGLE_H

class Rectangle{
	private:
		double length;
		double width;
		
	public:
		bool setLength(double);
		bool setWidth(double);
		double getLength();
		double getWidth();
		double getArea();
};
#endif
