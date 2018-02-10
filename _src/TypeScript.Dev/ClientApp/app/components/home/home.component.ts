import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
	selector: 'home',
	templateUrl: './home.component.html'
})

export class HomeComponent {
	public item: TodoItem;
	public todoLists: TodoLists[];

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		http.get(baseUrl + 'api/TodoLists/GetTodoLists').subscribe(result => {
			this.todoLists = result.json() as TodoLists[];
		}, error => console.error(error));
	}

	public students = [{}];
	public student = new Student("FirstName", "LastName");

	public addName(fName: string, lName: string) {

		this.student = new Student(fName, lName);
		this.students.push(this.student);
	}
}

interface TodoLists {
	name: string;
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