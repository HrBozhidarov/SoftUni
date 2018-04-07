import java.util.Scanner;

public class FitStringIn20Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input=scanner.nextLine();

        if (input.length()<20) {
            for (int i=input.length();i<20;i++) {
                input+='*';
            }
            System.out.println(input);
        }
        else if (input.length()>20) {
            System.out.println(input.substring(0,20));
        }
        else {
            System.out.println(input);
        }
    }
}
