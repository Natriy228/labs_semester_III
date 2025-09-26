use std::io;
use std::io::Write;
use std::process;
use std::env;

fn error_exit(comment: &str) {
	println!("{}", comment);
	process::exit(-1);
}

fn read_line(comment: &str, is_on_one_line: bool) -> String {
	if is_on_one_line {
		print!("{}", comment);
		io::stdout().flush();
	}
	else {
		println!("{}", comment);
	}
    let mut string: String = String::new();
    io::stdin().read_line(&mut string)
        .ok()
        .expect("Error read line!");
    return string;
}

fn main() {
	let args: Vec<_> = env::args().collect();
	let mut need_hand_input = false;
	let mut num_inputs: [f64; 3] = [0.0, 0.0, 0.0];
	
    if args.len() > 3 {
		for i in 1..4 {
			let convertation_result = args[i].trim().parse::<f64>();
			match convertation_result {
				Ok(n) => num_inputs[i - 1] = n,
				Err(e) => { println!("\x1b[91mОшибка в консольных аргументах ({}-й, не конвертируется в число). Переход к ручному вводу.\x1b[0m", i); need_hand_input = true; break; }
			}
			if (i == 1 && num_inputs[0] == 0.0) {
				println!("\x1b[91mОшибка в консольных аргументах ({}-й, не может быть нулём). Переход к ручному вводу.\x1b[0m", i);
				need_hand_input = true;
				break;
			}
		}
    }
	else {
		println!("\x1b[91mОшибка в консольных аргументах (меньше, чем 3). Переход к ручному вводу.\x1b[0m");
		need_hand_input = true;
	}
	
	if need_hand_input {
		let premessages: [&str; 3] = ["Введите коэффициент A: ", "Введите коэффициент B: ", "Введите коэффициент C: "];
		let mut input_finished: bool = false;
		for i in 0..3 {
			let mut input_finished: bool = false;
			while !input_finished {
				let current_input = read_line(premessages[i], true);
				let convertation_result = current_input.trim().parse::<f64>();
				match convertation_result {
					Ok(n) => num_inputs[i] = n,
					Err(e) => { println!("\x1b[91mВедённое значение не является числом!\x1b[0m"); continue; }
				}
				if (i == 0 && num_inputs[0] == 0.0) {
					println!("\x1b[91mПервый коэффициент не может быть нулём!\x1b[0m");
					continue;
				}
				input_finished = true;
			}
		}
	}
	
	let d = num_inputs[1] * num_inputs[1] - 4.0 * num_inputs[0] * num_inputs[2];
	if d < 0.0 {
		println!("\x1b[91mДискриминант меньше нуля! Корней нет.\x1b[0m");
	}
	else if d == 0.0 {
		let c = -1.0 * num_inputs[1] / 2.0 / num_inputs[0];
		if c < 0.0 {
			println!("\x1b[91mДискриминант равен нулю. Корней нет.\x1b[0m");
		}
		else if c == 0.0 {
			println!("\x1b[92mДискриминант равен нулю. Единственный корень: {}.\x1b[0m", c);
		}
		else {
			println!("\x1b[92mДискриминант равен нулю. Корни: {}, {}.\x1b[0m", f64::sqrt(c), -1.0 * f64::sqrt(c));
		}
	}
	else {
		let c1 = (-1.0 * num_inputs[1] + f64::sqrt(d)) / 2.0 / num_inputs[0];
		let c2 = (-1.0 * num_inputs[1] - f64::sqrt(d)) / 2.0 / num_inputs[0];
		if c1 < 0.0 && c2 < 0.0 { println!("\x1b[91mДискриминант больше нуля. Корней нет.\x1b[0m"); process::exit(0); }
		print!("\x1b[92mДискриминант больше нуля. Корни: ");
		if c1 == 0.0 { print!("{} и ", c1); }
		if c1 > 0.0 { print!("{}, {} и ", f64::sqrt(c1), -1.0 * f64::sqrt(c1)); }
		if c2 == 0.0 { print!("{}", c2); }
		if c2 > 0.0 { print!("{}, {}", f64::sqrt(c2), -1.0 * f64::sqrt(c2)); }
	}
	println!("\x1b[0m");
}