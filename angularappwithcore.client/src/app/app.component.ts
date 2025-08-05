import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PostService } from './services/post.service'; 

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html', 
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  allPosts: any[] = [];
  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getPosts().subscribe((response: any) => {
      this.allPosts = response;
      console.log(this.allPosts);
    });
  }
}
