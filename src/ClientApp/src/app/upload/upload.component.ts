import { Component, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http'

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.baseUrl = baseUrl;
  }
  public uploading: boolean;
  public progress: number;
  public response: Response;
  private baseUrl: string;
   
  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    const request = new HttpRequest('POST', this.baseUrl +`api/file/upload`, formData, {
      reportProgress: true
    });

    this.http.request(request).subscribe(event => {
      this.uploading = true;
      if (event.type === HttpEventType.UploadProgress)
       this.progress = Math.round(100 * event.loaded / event.total);
       if (event.type === HttpEventType.Response) {
         this.uploading = false;
         this.response = event.body as Response;
         this.response.status = event.status;
       }
    });
  }
}

interface Response {
  message: string;
  count: number;
  size: string;
  status: number;
}
