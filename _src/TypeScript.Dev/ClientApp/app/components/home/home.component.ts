import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
	selector: 'home',
	templateUrl: './home.component.html'
})

export class HomeComponent {

	public data: string;
	public item: TodoItem;

	//public postItem(http: Http, @Inject('BASE_URL') baseUrl: string) {
	//	http.post(baseUrl + 'api/SampleData/PostData', this.item).subscribe(result => {
	//		this.data = result.json() as string;
	//	}, error => console.error(error));
	//}

	public students = [{}];
	public student = new Student("FirstName", "LastName");

	public addName(fName: string, lName: string) {

		this.student = new Student(fName, lName);
		this.students.push(this.student);
	}
}


interface TodoItem {
	title: string;
	description: string;
}


interface Person {
	firstName: string;
	lastName: string;
}

class Student {
	fullName: string;

	constructor(public firstName: string, public lastName: string) {
		this.fullName = firstName + " " + lastName;
	}
}


function greeter(name) {
	return "Namn: " + name;
}