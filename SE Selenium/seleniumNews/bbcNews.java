/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package autotest;

import java.util.ArrayList;
import java.util.List;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;


/**
 *
 * @author User
 */
public class Autotest {

    static List<WebElement> news = new ArrayList();
    static List<String> headings = new ArrayList();
    static List<String> contents = new ArrayList();
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        methodTwo();
    }
    
    public static void methodTwo(){
        System.setProperty("webdriver.chrome.driver","C:\\chromedriver.exe");
        //Instance Webdriver/create project
        
        WebDriver driver = new ChromeDriver();
        
        driver.navigate().to("http://www.bbc.com/news");
        
        
        try{
            Thread.sleep(1000);
        }catch(Exception e){
        }
        
        
        news = driver.findElements(By.className("nw-c-top-stories__secondary-item"));
        for(int i=0;i<news.size();i++){
            String[] singleNews = news.get(i).getText().split("\n");
            headings.add(singleNews[0]);
            contents.add(singleNews[1]);
            System.out.println("************************************************");
            System.out.printf("\nHeading %s \n %s\n",singleNews[0],singleNews[1]);
            System.out.println("************************************************");
        }
        
        driver.navigate().to("localhost:4000");
        
        try{
            Thread.sleep(1000);
        }catch(Exception e){
        }
        
        WebElement userName = driver.findElement(By.id("exampleInputEmail1"));
        WebElement password = driver.findElement(By.id("exampleInputPassword1"));
        WebElement login = driver.findElement(By.className("login-button"));
        
        userName.sendKeys("java");
        password.sendKeys("java");
        login.click();
        
        try{
            Thread.sleep(1000);
        }catch(Exception e){
        }
        
        WebElement add = driver.findElements(By.tagName("a")).get(1);
        add.click();
        
        try{
            Thread.sleep(2000);
        }catch(Exception e){}
        
        WebElement word = driver.findElement(By.id("exampleInputEmail1"));
        WebElement meaning = driver.findElement(By.id("exampleInputPassword1"));
        
        WebDriverWait wait = new WebDriverWait(driver,30);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("add-but")));
        WebElement addButton = driver.findElement(By.id("add-but"));
        
        for(int i=0;i<headings.size();i++){
            System.out.printf("Heading %s \n Content %s\n",headings.get(i),contents.get(i));
            word.sendKeys(headings.get(i));
            meaning.sendKeys(contents.get(i));
            
            addButton.click();
  
            word.clear();
            meaning.clear();
        }
        
        try{
            Thread.sleep(2000);
        }catch(Exception e){
        }
        
        driver.close();
    }
   