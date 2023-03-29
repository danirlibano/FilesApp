import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  file: File | any = null;

  fileId: MyFile | any = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  onFilechange(event: any) {
    console.log(event.target.files[0])
    this.file = event.target.files[0]
  }


  upload() {
    let formParams = new FormData();
    formParams.append('file', this.file)
    this.http.post<MyFile>(this.baseUrl + 'fileupload', formParams).subscribe(result => {
      window.location.reload();
    }, error => console.error(error));
  }

}

interface MyFile {
  id: number;
}
