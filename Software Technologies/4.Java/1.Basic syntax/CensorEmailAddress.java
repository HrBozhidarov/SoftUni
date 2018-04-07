import java.util.Scanner;

public class CensorEmailAddress {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String email=scanner.nextLine();
        String text=scanner.nextLine();

        int domainIndex=email.indexOf("@");
        String asteriks=new String(new char[domainIndex]).replace('\0','*');
        String replacor=asteriks + email.substring(domainIndex);

        System.out.println(text.replaceAll(email,replacor));
    }
}
