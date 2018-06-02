/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pathgenerator;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author xero
 */
public class PathGenerator {

    /**
     * @param args the command line arguments
     */
    
    static List<Object> combinedPaths = new ArrayList();
    static List<List<Object>> selectedPaths = new ArrayList();
    static Scanner scanner = new Scanner(System.in);
    
    public static void main(String[] args) {
        System.out.print("Enter the absolute path of the program: ");
        String pathName = scanner.nextLine();
        Path filePath = Paths.get(pathName);
        InputStream input = null;
        try{
            input = Files.newInputStream(filePath);
            BufferedReader reader = new BufferedReader(new InputStreamReader(input));
            String s = null;
            String code = "";
            while(true){
                s = reader.readLine();
                if(s == null){
                    break;
                }
                code = code+s+"\n";
            }
            code = code.trim();
            // get the contents of the function
            code = addIdentifier(getBody(code, code.indexOf("{")));

            findCombinedPath(getNewElseAddedCode(code));
            System.out.println("\tPossiblepaths");
            System.out.println("-------------------------------------");
            printPossiblePaths(parseCombinedPaths());
            
            input.close();
        }catch(IOException e){
            System.out.println(e);
        }
    }
    
    public static int checkStatement(String s){
        s = s.trim();
        int answer = -1;
        // 0 = normal statement
        // 1 = if statement
        // 2 = else statement
        String[] keywords = {"if","else","return"};
        if(s.startsWith(keywords[0])){
            answer = 1;
        }
        else if(s.startsWith(keywords[1])){
            answer = 2;
        }
        else if(s.startsWith(keywords[2])){
            answer = 3;
        }
        else if(s.endsWith(";")){
            answer = 0;
        }

        return answer;
    }
    
    public static String addIdentifier(String code){
        int counter = 1;
        String[] tokens = code.split("\n");
        String modified = "";
        int status;
        List<Integer> offsets = new ArrayList();
        for(String token:tokens){
            token = token.trim();
            status = checkStatement(token);
            switch(status){
                case 0 : token = counter+token;counter++;break;
                case 1 : token = token+counter+"(T)";offsets.add(counter);counter++;break;
                case 2 : token = token+offsets.get(offsets.size()-1)+("(F)");offsets.remove(offsets.size()-1);break;
                case 3 : token = counter+"/"+token;counter++;break;
            }
            modified = modified + token + "\n";
        }
        return modified;
    }
    
    public static String addEndElse(String codeModified){
        System.out.println(codeModified);
        return "";
    }
    
    public static void handleElse(boolean ifOpen,int counter,String token){
        if(ifOpen){
            
        }
    }
    public static String addElse(String code){
    // we assumed that each if case has a mathced else case        

        return "";
    }
    public static String getBody(String code,int index){
        String result = "";
        char[] codeArray = code.toCharArray();
        if(index <= code.length() && code.charAt(index) == '{'){
            int count = 1;
            int in = index+1;
            while(count >= 1 && in < code.length()){
                if(codeArray[in] == '{'){
                    count+=1;
                }
                else if(codeArray[in] == '}'){
                    count-=1;
                    if(count == 0){
                        continue;
                    }
                }
                result+=codeArray[in];
                in+=1;
            }
        }
        return result.trim();
    }
    public static List<Object>  findCombinedPath(String modCode){
        System.out.println(modCode);
        String[] statements = modCode.split("\n");
        int status;
        Object o;
        for(String s:statements){
            status = checkAnsi(s);
            switch (status) {
                case 0:
                    o = getNumber(s);
                    combinedPaths.add(o);
                    break;
                case 1:
                case 2:
                    o = s.substring(s.lastIndexOf("{")+1);
                    combinedPaths.add(o);
                    break;
                case 3:
                    o = getNumberSpecial(s);
                    combinedPaths.add(o);
                    break;
                case 4:
                    o = "-";
                    combinedPaths.add(o);
                    break;
                default:
                    break;
            }
        }
        return combinedPaths;
    }
    public static int checkAnsi(String s){
        char[] chars = s.toCharArray();
        // 0 = number
        // 1 = if
        // 2 = else
        // 3 = return
        // 4 = -
        int res = -1;
        if(chars.length != 0){
            if(s.contains("return")){
                res = 3;
            }
            else if(chars[0] > 48 && chars[0] <= 57){
                res = 0;
            }
            else if(s.startsWith("if")){
                res = 1;
            }
            else if(s.startsWith("else")){
                res = 2;
            }
            else if(s.endsWith("-")){
                res = 4;
            }
            
        }
        return res;
    }
    
    public static int getLastIndex(String s){
        char[] chars = s.toCharArray();
        int i = 0;
        while(chars[i] >= 48 && chars[i] <= 57){
            i+=1;
        }
        return i;
    }
    
    public static String getNumberSpecial(String s){
        return (s.substring(0,getLastIndex(s)+1));
    }
    
    public static String getNumber(String s){
        return (s.substring(0,getLastIndex(s)));
    }
    
    public static List<Integer> getElseInitialIndexes(String code){
        int indexCounter = 0;
        List<Integer> indexes = new ArrayList();
        String[] statements = code.split("\n");
        for(String statement:statements){
            if(statement.contains("else")){
                int offset = statement.indexOf("{");
                indexes.add(indexCounter+offset);
            }
            indexCounter+=statement.length()+1;
        }
        return indexes;
    }
    
    public static List<Integer> getElseLastIndexes(String code,List<Integer> initialIndexes){
        List<Integer> endIndexes = new ArrayList();
        for(int i:initialIndexes){
            endIndexes.add(i+getBody(code,i).length()+2);
        }
        return endIndexes;
    }
    
    public static List<Integer> getElseIndexes(String code){
        return getElseLastIndexes(code, getElseInitialIndexes(code));
    }
    
    public static List<Object> parseCombinedPaths(){
        List<List<Object>> obj = new ArrayList<>();
        List<Object> main = new ArrayList<>();
        obj.add(main);
        //
        for(Object s:combinedPaths){
            String ss = String.valueOf(s);
            try{
                int a = Integer.valueOf(ss)/2;
                ((List<Object>)(getCurrentObject(obj,-1))).add(ss);
            }catch(Exception e){
                if(ss.contains("(T)")){
                    obj.add(new ArrayList<>());
                    getCurrentObject(obj, -1).add(ss);
                }
                else if(ss.contains("(F)") || ss.contains("-")){
                    getCurrentObject(obj, -2).add(getCurrentObject(obj, -1));
                    obj.remove(obj.size()-1);
                    if(ss.contains("(F)")){
                        obj.add(new ArrayList<>());
                        getCurrentObject(obj, -1).add(ss);
                    }
                }
                else if(ss.contains("/")){
                    ((List<Object>)(getCurrentObject(obj,-1))).add(ss);
                }
            }
        }
        return obj.get(0);
    }
    
    public static boolean printCombinedPaths(List<Object> lists){
        boolean stop = false;
        for(int i=0;i<lists.size();){
            if(!stop){
                if(lists.get(i) instanceof List){
                stop = printCombinedPaths(selector((List<Object>)lists.get(i),(List<Object>)lists.get(i+1)));
                i+=2;
                }
                else if(String.valueOf(lists.get(i)).contains("/")){
                    System.out.print(lists.get(i)+"-");
                    stop = true;
                    break;
                }
                else{
                    System.out.print(lists.get(i)+"-");
                    i+=1;
                }
            }
            else{
                break;
            }
        }
        return stop;
    }
    
    public static void printPossiblePaths(List<Object> list){
        for(int i=0;i<2;i++){
            System.out.println("Path "+(i+1));
            printCombinedPaths(list);
            System.out.println("");
        }
        System.out.println("------------------------------------");
        System.out.println("It only prints False and True way\n");
    }
    
    public static List<Object> selector(List<Object> t,List<Object> f){
        List<Object> who;
        if(selectedPaths.contains(t)){
            who = f;
        }
        else{
            who = t;
            selectedPaths.add(t);
        }
        return who;
    }
    
    
    public static List<Object> getCurrentObject(List<List<Object>> s,int index){
        return s.get(s.size()+index);
    }
    
    public static String getNewElseAddedCode(String code){
        List<Integer> list = getElseIndexes(code);
        String newS = "";
        int index = 0;
        int status = 0;
        String[] states = code.split("\n");
        for(String s:states){
            for(int i=0;i<list.size();i++){
                if(index-status == list.get(i)){
                    s = s.replace("}", "}-");
                    status += 1;
                    break;
                }
            }
            newS = newS + s+"\n";
            index += s.length()+1;
        }
        return newS;
    }
    
}


