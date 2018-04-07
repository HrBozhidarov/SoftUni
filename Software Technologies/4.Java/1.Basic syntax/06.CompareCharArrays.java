import java.util.Scanner;

public class CompareCharArrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] arr1=scanner.nextLine().split(" ");
        String[] arr2=scanner.nextLine().split(" ");

        int minLength=Math.min(arr1.length,arr2.length);

        for (int i=0;i<minLength;i++) {
            if (arr1[i].charAt(0)-'0'<arr2[i].charAt(0)-'0') {
                System.out.println(String.join("",arr1));
                System.out.println(String.join("",arr2));
                return;
            }
            else if(arr1[i].charAt(0)-'0'>arr2[i].charAt(0)-'0') {
                System.out.println(String.join("",arr2));
                System.out.println(String.join("",arr1));
                return;
            }
        }

        if (arr1.length<arr2.length) {
            System.out.println(String.join("",arr1));
            System.out.println(String.join("",arr2));
        }
        else {
            System.out.println(String.join("",arr2));
            System.out.println(String.join("",arr1));
        }
    }
}
