import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public fileList: FileData[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<FileData[]>(baseUrl + 'fileupload').subscribe(result => {
      this.fileList = result;
    }, error => console.error(error));
  }
}

interface FileData {
  name: string;
}
