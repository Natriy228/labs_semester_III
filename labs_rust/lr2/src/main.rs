use std::io;
use std::io::Write;

trait Quadriable {
	fn area(&self) {
		println!("There is no figure to count!");
	}
}

trait Lox {
	fn area(&self) {
		println!("There is no figure to count!");
	}
}

struct rectangle {
	width: f64,
	height: f64
}

struct square {
	side: f64
}

struct circle {
	radius: f64
}

impl Quadriable for rectangle {
	fn area(&self) {
		println!("Площадь этого прямоугольника {}.", self.width * self.height);
	}
}

impl Quadriable for square {
	fn area(&self) {
		println!("Площадь этого квадрата {}.", self.side * self.side);
	}
}

impl Quadriable for circle {
	fn area(&self) {
		println!("Площадь этого круга {}.", std::f64::consts::PI * self.radius * self.radius);
	}
}

fn calculate_area<T: Quadriable>(item: &T) {
	item.area();
}

fn main() {
	let rect1 = rectangle { width: 10.0, height: 5.0 };
	calculate_area(&rect1);
	let square1 = square { side: 27.0 };
	calculate_area(&square1);
	let circle1 = circle { radius: 5.0 };
	calculate_area(&circle1);
}