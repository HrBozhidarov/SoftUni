import javax.print.DocFlavor;
import java.util.Scanner;

public class ChangeToUppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input=scanner.nextLine();
        String beginTag="<upcase>";
        String endTag="</upcase>";
        int delete=endTag.length()-1;
        int index=0;

        while (true) {
            index=input.indexOf(beginTag);

            if (index<0) {
                break;
            }

            int indexEnd=input.indexOf(endTag);

            String uppercaseSeq=input.substring(index+delete,indexEnd).toUpperCase();

            input=input.substring(0,index) + uppercaseSeq + input.substring(indexEnd+delete+1);
        }

        System.out.println(input);
    }
}
