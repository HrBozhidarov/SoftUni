import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String symbol = scanner.nextLine();

        if (symbol.equals("a") || symbol.equals("e") || symbol.equals("i")
                || symbol.equals("o") || symbol.equals("u")) {
            System.out.println("vowel");
        }
        else if(Character.isDigit(symbol.charAt(0))) {
            System.out.println("digit");
        }
        else {
            System.out.println("other");
        }
    }
}
