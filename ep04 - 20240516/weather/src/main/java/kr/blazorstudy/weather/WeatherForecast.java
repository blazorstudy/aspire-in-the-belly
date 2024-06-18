package kr.blazorstudy.weather;

public class WeatherForecast {
  public String date;
  public int TemperatureC;
  public String Summary;
  public int TemperatureF;

  public WeatherForecast(String date, int TemperatureC, String Summary) {
    this.date = date;
    this.TemperatureC = TemperatureC;
    this.Summary = Summary;
    this.TemperatureF = 32 + (int)(TemperatureC / 0.5556);
  }
}
