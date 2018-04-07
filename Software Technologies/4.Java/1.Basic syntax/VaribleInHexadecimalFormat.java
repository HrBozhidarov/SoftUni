import java.util.Scanner;

public class VaribleInHexadecimalFormat {
    public static void main(String[] args){
        Scanner scanner=new Scanner(System.in);

        int hexadecimalNumber= Integer.parseInt(scanner.nextLine(),16);
        System.out.println(hexadecimalNumber);
    }
}
