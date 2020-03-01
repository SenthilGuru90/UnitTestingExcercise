import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './student.component.html'
})
export class StudentComponent {
  public lstStudents: Student[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Student[]>(baseUrl + 'student').subscribe(result => {
      this.lstStudents = result;
    }, error => console.error(error));
  }
}

interface Student {
  id: string;
  firstname: string;
  lastname: string;
  grade: string;
}
