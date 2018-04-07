import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;

public class CountWorkingDays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LocalDate startDate = LocalDate.parse(scanner.nextLine(),
                DateTimeFormatter.ofPattern("dd-MM-yyyy"));

        LocalDate endDate = LocalDate.parse(scanner.nextLine(),
                DateTimeFormatter.ofPattern("dd-MM-yyyy"));

        int[] holidayDays = {
                1, 3, 1, 6, 24, 6, 22, 1, 24, 25, 26
        };

        int[] holidayMounths = {
                1, 3, 5, 5, 5, 9, 9, 10, 12, 12, 12
        };

        endDate = endDate.plusDays(1);
        int countWorkDays=0;

        for (LocalDate currentDate=startDate;currentDate.isBefore(endDate);
             currentDate=currentDate.plusDays(1)) {

            boolean ifHolidayDay=false;
            for (int i=0;i<holidayDays.length;i++) {
                if (currentDate.getMonth().getValue()==holidayMounths[i]
                        && currentDate.getDayOfMonth()==holidayDays[i]) {
                    ifHolidayDay=true;
                    break;
                }

                if (currentDate.getDayOfWeek().getValue()==7
                        || currentDate.getDayOfWeek().getValue()==6) {
                    ifHolidayDay=true;
                    break;
                }
            }

            if (ifHolidayDay) {
                continue;
            }

            countWorkDays++;
        }

        System.out.println(countWorkDays);
    }
}
