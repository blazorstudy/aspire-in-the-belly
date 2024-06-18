package kr.blazorstudy.weather;

import java.util.Random;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class WeatherController {
      @GetMapping("/hello")
      public String hello() {
          return "Hello, Aspire Java!";
      }

      @GetMapping("/weatherforecast")
      public WeatherForecast[] weatherforecast() {

        var random = new Random();
        
        return new WeatherForecast[] {
            new WeatherForecast("2021-10-01", random.nextInt(45), "서울"),
            new WeatherForecast("2021-10-02", random.nextInt(45), "대구"),
            new WeatherForecast("2021-10-03", random.nextInt(45), "부산"),
            new WeatherForecast("2021-10-04", random.nextInt(45), "광주"),
            new WeatherForecast("2021-10-05", random.nextInt(45), "인천")
        };
      }
}
