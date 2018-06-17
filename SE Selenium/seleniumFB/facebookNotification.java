/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package autotest;

import java.util.Scanner;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
/**
 *
 * @author User
 */
public class Autotest {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        methodThree();
    }
    public static void methodThree(){
        System.setProperty("webdriver.chrome.driver","C:\\chromedriver.exe");
        //Instance Webdriver/create project
        int notificationNum = 0;
        WebDriver driver = new ChromeDriver();
        
        Scanner in = new Scanner(System.in);
        System.out.println("Enter your email: ");
        String stEmail = in.nextLine();
        System.out.println("Enter your password: ");
        String stPasswd = in.nextLine();
        
        driver.navigate().to("http://www.facebook.com");
        
        WebElement email = driver.findElement(By.id("email"));
        WebElement password = driver.findElement(By.id("pass"));
        WebElement ok = driver.findElement(By.id("u_0_2"));
        WebElement notificationCount = driver.findElement(By.id("notificationsCountValue"));
        
        email.sendKeys(stEmail);
        password.sendKeys(stPasswd);
        ok.click();
        
        notificationNum = Integer.valueOf(notificationCount.getText());
        
        try{
            Thread.sleep(2000);
        }catch(Exception e){
        }

        System.out.println("You have "+notificationNum+" facebook notificatio");
        
        driver.close();
    }
    
}
