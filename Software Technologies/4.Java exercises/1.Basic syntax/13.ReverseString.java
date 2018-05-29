import java.lang.reflect.Array;
        import java.util.Arrays;
        import java.util.Scanner;

public class ReverseString {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char[] input = scanner.nextLine().toCharArray();
        String result= new StringBuilder(new String(input)).reverse().toString();
        System.out.println(result);
    }
}
